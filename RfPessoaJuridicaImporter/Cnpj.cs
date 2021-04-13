

using RfPessoaJuridicaImporter;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;


public class Cnpj
{

    public IConfigurationRoot Configuration { get; set; }
    public SqlConnection Connection { get; set; }
    public SqlCommand Command { get; set; }

    long _bulkSize = 20000;
    long _countCnae = 0;
    long _countPj = 0;
    DateTime _dataBaseArquivoImportacao;

    IEnumerable<CnaeSubClasse> _cnaeSubclasse;

    DataTable _tblPj;
    DataTable _tblEndereco;
    DataTable _tblTelefone;
    DataTable _tblCnae;


    public void Run(string[] input_list)
    {
        Configure();
        Connect();
        Init();

        _cnaeSubclasse = GetCNAE();


        // Itera sobre sequencia de arquivos (p/ suportar arquivo dividido pela RF)
        foreach (var file_path in input_list)
        {
            _dataBaseArquivoImportacao = new DateTime();
            Console.WriteLine("Processando arquivo: " + file_path);
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            _tblPj = PjTableStructure();
            _tblEndereco = EnderecoTableStructure();
            _tblTelefone = TelefoneTableStructure();
            _tblCnae = CnaeTableStructure();

            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(file_path);
            var currentLine = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if ("1" == SubStr(line, Constantes.GERAL_COLUNAS.GetValueOrDefault("REGISTROS_TIPOS")))
                {

                    var pj = new RfPessoaJuridica()
                    {
                        Cnpj = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CNPJ))),
                        RazaoSocial = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_RAZAO_SOCIAL)),
                        NomeFantasia = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_NOME_FANTASIA)),
                        CnaeFiscal = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CNAE_FISCAL)),
                        CapitalSocial = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CAPITAL_SOCIAL))) / 100,
                        DataInicioAtividades = GetValidDate(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_DATA_INICIO_ATIV))),
                        NaturezaJuridica = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_COD_NAT_JURIDICA))),
                        SituacaoCadastral = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_SITUACAO)),
                        DataSituacaoCadastral = GetValidDate(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_DATA_SITUACAO))),
                        MotivoSituacaoCadastral = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_MOTIVO_SITUACAO)),
                        OptanteMei = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_OPC_MEI)) == "S",
                        OptanteSimples = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_OPC_MEI)) == "S",
                        Email = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_EMAIL)),
                        DataBaseImportacao = _dataBaseArquivoImportacao
                    };

                    var end = new RfEndereco()
                    {
                        Cnpj = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CNPJ))),
                        Bairro = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_BAIRRO)),
                        Cep = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CEP))),
                        Complemento = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_COMPLEMENTO)),
                        Logradouro = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_LOGRADOURO)),
                        Numero = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_NUMERO)),
                        TipoLogradouro = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_TIPO_LOGRADOURO)),
                        Uf = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_UF)),
                        IdMunicipio = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_COD_MUNICIPIO))),
                        Municipio = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_MUNICIPIO)),
                    };
                    var tel1 = new RfTelefone()
                    {
                        Cnpj = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CNPJ))),
                        Telefone = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_DDD_1)) + SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_TELEFONE_1))
                    };
                    var tel2 = new RfTelefone()
                    {
                        Cnpj = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_CNPJ))),
                        Telefone = SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_DDD_2)) + SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.EMP_TELEFONE_2))
                    };

                    AddToBulk(_countPj++, pj, end, tel1, tel2);
                    if (currentLine % _bulkSize == 1)
                    {
                        WriteBulkToDb();
                        ClearBulk();
                    }
                }
                else if ("6" == SubStr(line, Constantes.GERAL_COLUNAS.GetValueOrDefault("REGISTROS_TIPOS")))
                {
                    var Cnpj = GetValidLong(SubStr(line, Constantes.EMPRESAS_COLUNAS.GetValueOrDefault(Constantes.CNA_CNPJ)));
                    for (int i = 1; i < 99; i++)
                    {
                        var RfPessoaJuridicaCnaeSubclasse = new RfPessoaJuridicaCnaeSubclasse
                        {
                            Cnpj = Cnpj,
                            IdCnaeSubclasse = SubStr(line, Constantes.CNAES_COLSPECS[i])
                        };
                        if (GetValidLong(RfPessoaJuridicaCnaeSubclasse.IdCnaeSubclasse) > 0)
                        {
                            AddToBulkCnae(_countCnae++, RfPessoaJuridicaCnaeSubclasse);
                        }
                        else
                        {
                            break;
                        }

                    }
                }

                currentLine++;
            }

            WriteBulkToDb();
            ClearBulk();
            file.Close();

            Console.WriteLine("{0} linhas processadas.", currentLine);
        }


    }

    private void ClearBulk()
    {
        // reset
        _tblPj = PjTableStructure();
        _tblEndereco = EnderecoTableStructure();
        _tblTelefone = TelefoneTableStructure();
        _tblCnae = CnaeTableStructure();
    }

    private IEnumerable<CnaeSubClasse> GetCNAE()
    {
        string urlCnae = @"https://servicodados.ibge.gov.br/api/v2/cnae/subclasses";
        Console.WriteLine($"Obtendo Dados CNAE de {urlCnae}.");
        string jsonString = new WebClient().DownloadString(urlCnae);
        var cnaeSubclasse = JsonConvert.DeserializeObject<List<CnaeSubClasse>>(jsonString);
        return cnaeSubclasse;
    }

    private DataTable PjTableStructure()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(long)));
        tbl.Columns.Add(new DataColumn("Cnpj", typeof(long)));
        tbl.Columns.Add(new DataColumn("RazaoSocial", typeof(string)));
        tbl.Columns.Add(new DataColumn("NomeFantasia", typeof(string)));
        tbl.Columns.Add(new DataColumn("CapitalSocial", typeof(decimal)));
        tbl.Columns.Add(new DataColumn("DataInicioAtividades", typeof(DateTime)));
        tbl.Columns.Add(new DataColumn("CnaeFiscal", typeof(string)));
        tbl.Columns.Add(new DataColumn("SituacaoCadastral", typeof(string)));
        tbl.Columns.Add(new DataColumn("DataSituacaoCadastral", typeof(DateTime)));
        tbl.Columns.Add(new DataColumn("MotivoSituacaoCadastral", typeof(string)));
        tbl.Columns.Add(new DataColumn("NaturezaJuridica", typeof(string)));
        tbl.Columns.Add(new DataColumn("OptanteMei", typeof(int)));
        tbl.Columns.Add(new DataColumn("OptanteSimples", typeof(int)));
        tbl.Columns.Add(new DataColumn("Email", typeof(string)));
        tbl.Columns.Add(new DataColumn("DataBaseImportacao", typeof(DateTime)));
        return tbl;
    }

    private DataTable EnderecoTableStructure()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(long)));
        tbl.Columns.Add(new DataColumn("Cnpj", typeof(long)));
        tbl.Columns.Add(new DataColumn("Cep", typeof(string)));
        tbl.Columns.Add(new DataColumn("TipoLogradouro", typeof(string)));
        tbl.Columns.Add(new DataColumn("Logradouro", typeof(string)));
        tbl.Columns.Add(new DataColumn("Numero", typeof(string)));
        tbl.Columns.Add(new DataColumn("Complemento", typeof(string)));
        tbl.Columns.Add(new DataColumn("Bairro", typeof(string)));
        tbl.Columns.Add(new DataColumn("IdMunicipio", typeof(long)));
        tbl.Columns.Add(new DataColumn("Uf", typeof(string)));
        tbl.Columns.Add(new DataColumn("Municipio", typeof(string)));
        return tbl;
    }

    private DataTable TelefoneTableStructure()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(long)));
        tbl.Columns.Add(new DataColumn("Cnpj", typeof(long)));
        tbl.Columns.Add(new DataColumn("Telefone", typeof(string)));
        return tbl;
    }

    private DataTable CnaeTableStructure()
    {
        DataTable tbl = new DataTable();
        tbl.Columns.Add(new DataColumn("Id", typeof(long)));
        tbl.Columns.Add(new DataColumn("Cnpj", typeof(long)));
        tbl.Columns.Add(new DataColumn("IdCnaeSubClasse", typeof(string)));
        return tbl;
    }

    private void AddToBulk(long id, RfPessoaJuridica pj, RfEndereco end, RfTelefone tel1, RfTelefone tel2)
    {
        // pj
        DataRow drPj = _tblPj.NewRow();
        drPj["Id"] = id;
        drPj["Cnpj"] = pj.Cnpj;
        drPj["RazaoSocial"] = pj.RazaoSocial;
        drPj["NomeFantasia"] = pj.NomeFantasia;
        drPj["CapitalSocial"] = pj.CapitalSocial;
        drPj["DataInicioAtividades"] = pj.DataInicioAtividades;
        drPj["CnaeFiscal"] = pj.CnaeFiscal;
        drPj["SituacaoCadastral"] = pj.SituacaoCadastral;
        drPj["DataSituacaoCadastral"] = pj.DataSituacaoCadastral;
        drPj["MotivoSituacaoCadastral"] = pj.MotivoSituacaoCadastral;
        drPj["NaturezaJuridica"] = pj.NaturezaJuridica;
        drPj["OptanteMei"] = pj.OptanteMei;
        drPj["OptanteSimples"] = pj.OptanteSimples;
        drPj["Email"] = pj.Email;
        drPj["DataBaseImportacao"] = pj.DataBaseImportacao;


        _tblPj.Rows.Add(drPj);

        // endereco
        DataRow drEndereco = _tblEndereco.NewRow();
        drEndereco["Id"] = id;
        drEndereco["Cnpj"] = end.Cnpj;
        drEndereco["Cep"] = end.Cep;
        drEndereco["TipoLogradouro"] = end.TipoLogradouro;
        drEndereco["Logradouro"] = end.Logradouro;
        drEndereco["Numero"] = end.Numero;
        drEndereco["Complemento"] = end.Complemento;
        drEndereco["Bairro"] = end.Bairro;
        drEndereco["IdMunicipio"] = end.IdMunicipio;
        drEndereco["Uf"] = end.Uf;
        drEndereco["Municipio"] = end.Municipio;

        _tblEndereco.Rows.Add(drEndereco);

        // telefone
        DataRow drTelefone = _tblTelefone.NewRow();
        drTelefone["Id"] = id;
        drTelefone["Cnpj"] = tel1.Cnpj;
        drTelefone["Telefone"] = tel1.Telefone;

        _tblTelefone.Rows.Add(drTelefone);

    }

    private void AddToBulkCnae(long id, RfPessoaJuridicaCnaeSubclasse cnae)
    {
            DataRow drCnae = _tblCnae.NewRow();
            drCnae["Id"] = id;
            drCnae["Cnpj"] = cnae.Cnpj;
            drCnae["IdCnaeSubclasse"] = cnae.IdCnaeSubclasse;
            _tblCnae.Rows.Add(drCnae);
    }

    private void WriteBulkToDb()
    {
        Console.WriteLine("Adicionando lote de {0}", _bulkSize);
        //create object of SqlBulkCopy which help to insert  
        SqlBulkCopy objbulk = new SqlBulkCopy(Connection);

        //assign Destination table name  
        objbulk.DestinationTableName = "PessoaJuridicaRF";
        Connection.Open();
        objbulk.WriteToServer(_tblPj);
        Connection.Close();

        objbulk.DestinationTableName = "TelefoneRF";
        Connection.Open();
        objbulk.WriteToServer(_tblTelefone);
        Connection.Close();

        objbulk.DestinationTableName = "EnderecoRF";
        Connection.Open();
        objbulk.WriteToServer(_tblEndereco);
        Connection.Close();

        objbulk.DestinationTableName = "RfPessoaJuridicaCnaeSubclasse";
        Connection.Open();
        objbulk.WriteToServer(_tblCnae);
        Connection.Close();
    }


    public int BoolToInt(bool value)
    {
        return value ? 1 : 0;
    }


    public string SubStr(string line, ValueTuple<int, int> tuple)
    {
        if(line.Length >= tuple.Item2)
            return line.Substring(tuple.Item1, tuple.Item2 - tuple.Item1).Trim().Replace("\'", "");

        return "";
    }
    private long GetValidLong(string data)
    {
        long result;
        if (long.TryParse(data, out result))
        {
            return result;
        }
        else
        {
            return 0;
        }
    }

    private DateTime GetValidDate(string date, string format = "yyyyMMdd")
    {
        DateTime result;
        if (DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
        {
            return result;
        }
        else
        {
            return new DateTime(0);
        }
    }

    /// <summary>
    /// Prepara conexão com o banco de dados
    /// </summary>
    public void Connect()
    {
        Connection = new SqlConnection(Configuration.GetConnectionString("DB"));
    }

    /// <summary>
    /// Executa um comando no banco de dados
    /// </summary>
    /// <param name="cmd">Comando</param>
    public void SqlExec(string cmd)
    {
        Command.CommandText = cmd;
        Command.ExecuteNonQuery();
    }

    /// <summary>
    /// Executa um `SELECT` que retorna um único campo no banco de dados
    /// </summary>
    /// <param name="cmd">Comando</param>
    /// <returns>Campo de resultado</returns>
    public String SqlField(string cmd)
    {
        var c = SqlScalar(cmd);
        if (c.Count > 0)
        {
            return c.First().ToString();
        }
        return null;
    }

    /// <summary>
    /// Retorna um `SELECT` de coluna como lista
    /// </summary>
    /// <param name="cmd">Comando</param>
    /// <returns>Lista de resultados</returns>
    public List<string> SqlScalar(string cmd)
    {
        Command.CommandText = cmd;
        SqlDataReader reader = Command.ExecuteReader();
        int columns = reader.FieldCount;

        List<string> resultList = new List<string>();
        while (reader.Read())
        {
            resultList.Add(reader.GetValue(0).ToString());
        }
        reader.Dispose();

        return resultList;
    }

    /// <summary>
    /// Inicializa a aplicação e cria suas tabelas se necessário
    /// </summary>
    public void Init()
    {
        Connection.Open();
        Command = Connection.CreateCommand();
        Command.CommandTimeout = 0;
        Command.Connection = Connection;
        // Tabelas de dados importados
        SqlExec(File.ReadAllText(Directory.GetCurrentDirectory() + "/Sql/Schema.sql"));
        Connection.Close();
        
    }

    /// <summary>
    /// Ajusta variáveis de configuração para execução
    /// </summary>
    public void Configure()
    {
        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        if (String.IsNullOrWhiteSpace(environment))
            throw new ArgumentNullException("Variável ASPNETCORE_ENVIRONMENT não encontrada.");

        Console.WriteLine("Ambiente: {0}", environment);

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environment}.json");

        Configuration = builder.Build();
    }
    

}
