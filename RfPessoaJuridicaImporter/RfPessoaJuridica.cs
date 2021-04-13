using System;
using System.Collections.ObjectModel;

public class RfPessoaJuridica
{
    public long Cnpj { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public decimal CapitalSocial { get; set; }
    public DateTime DataInicioAtividades { get; set; }
    public string CnaeFiscal { get; set; }
    public string SituacaoCadastral { get; set; }
    public DateTime DataSituacaoCadastral { get; set; }
    public string MotivoSituacaoCadastral { get; set; }
    public long NaturezaJuridica { get; set; }
    public bool OptanteMei { get; set; }
    public bool OptanteSimples { get; set; }
    public string Email { get; set; }
    public DateTime DataBaseImportacao { get; set; }

    public RfEndereco Endereco { get; set; }
    public Collection<RfTelefone> Telefone { get; set; }
    public Collection<RfPessoaJuridicaCnaeSubclasse> CnaePj { get; set; }
    public RfMotivoSituacao RfMotivoSituacao { get; set; }

}

public class RfEndereco
{
    public long Cnpj { get; set; }
    public long Cep { get; set; }
    public string TipoLogradouro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Uf { get; set; }
    public long IdMunicipio { get; set; }
    public string Municipio { get; set; }

}

public class RfTelefone
{
    public long Cnpj { get; set; }
    public string Telefone { get; set; }

}

public class RfPessoaJuridicaCnaeSubclasse
{
    public long Cnpj { get; set; }
    public string IdCnaeSubclasse { get; set; }
    public CnaeSubClasse CnaeSubclasse { get; set; }
}


public class RfMotivoSituacao
{
    public string CodigoMotivo { get; set; }
    public string Descricao { get; set; }
}
