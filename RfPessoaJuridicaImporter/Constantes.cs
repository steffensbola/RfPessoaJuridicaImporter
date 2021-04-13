using System;
using System.Collections.Generic;

namespace RfPessoaJuridicaImporter
{
    public static class Constantes
    {

        public static string EMPRESAS = "empresas";

        public static string SOCIOS = "socios";

        public static string CNAES_SECUNDARIOS = "cnaes_secundarios";

        public static string EMP_CNPJ = "cnpj";

        public static string EMP_MATRIZ_FILIAL = "matriz_filial";

        public static string EMP_RAZAO_SOCIAL = "razao_social";

        public static string EMP_NOME_FANTASIA = "nome_fantasia";

        public static string EMP_SITUACAO = "situacao";

        public static string EMP_DATA_SITUACAO = "data_situacao";

        public static string EMP_MOTIVO_SITUACAO = "motivo_situacao";

        public static string EMP_NM_CIDADE_EXTERIOR = "nm_cidade_exterior";

        public static string EMP_COD_PAIS = "cod_pais";

        public static string EMP_NOME_PAIS = "nome_pais";

        public static string EMP_COD_NAT_JURIDICA = "cod_nat_juridica";

        public static string EMP_DATA_INICIO_ATIV = "data_inicio_ativ";

        public static string EMP_CNAE_FISCAL = "cnae_fiscal";

        public static string EMP_TIPO_LOGRADOURO = "tipo_logradouro";

        public static string EMP_LOGRADOURO = "logradouro";

        public static string EMP_NUMERO = "numero";

        public static string EMP_COMPLEMENTO = "complemento";

        public static string EMP_BAIRRO = "bairro";

        public static string EMP_CEP = "cep";

        public static string EMP_UF = "uf";

        public static string EMP_COD_MUNICIPIO = "cod_municipio";

        public static string EMP_MUNICIPIO = "municipio";

        public static string EMP_DDD_1 = "ddd_1";

        public static string EMP_TELEFONE_1 = "telefone_1";

        public static string EMP_DDD_2 = "ddd_2";

        public static string EMP_TELEFONE_2 = "telefone_2";

        public static string EMP_DDD_FAX = "ddd_fax";

        public static string EMP_NUM_FAX = "num_fax";

        public static string EMP_EMAIL = "email";

        public static string EMP_QUALIF_RESP = "qualif_resp";

        public static string EMP_CAPITAL_SOCIAL = "capital_social";

        public static string EMP_PORTE = "porte";

        public static string EMP_OPC_SIMPLES = "opc_simples";

        public static string EMP_DATA_OPC_SIMPLES = "data_opc_simples";

        public static string EMP_DATA_EXC_SIMPLES = "data_exc_simples";

        public static string EMP_OPC_MEI = "opc_mei";

        public static string EMP_SIT_ESPECIAL = "sit_especial";

        public static string EMP_DATA_SIT_ESPECIAL = "data_sit_especial";

        public static string SOC_CNPJ = "cnpj";

        public static string SOC_TIPO_SOCIO = "tipo_socio";

        public static string SOC_NOME_SOCIO = "nome_socio";

        public static string SOC_CNPJ_CPF_SOCIO = "cnpj_cpf_socio";

        public static string SOC_COD_QUALIFICACAO = "cod_qualificacao";

        public static string SOC_PERC_CAPITAL = "perc_capital";

        public static string SOC_DATA_ENTRADA = "data_entrada";

        public static string SOC_COD_PAIS_EXT = "cod_pais_ext";

        public static string SOC_NOME_PAIS_EXT = "nome_pais_ext";

        public static string SOC_CPF_REPRES = "cpf_repres";

        public static string SOC_NOME_REPRES = "nome_repres";

        public static string SOC_COD_QUALIF_REPRES = "cod_qualif_repres";

        public static string CNA_CNPJ = "cnpj";

        public static string CNA_CNAE = "cnae";

        public static string CNA_ORDEM = "cnae_ordem";

        public static Dictionary<string, string> REGISTROS_TIPOS = new Dictionary<string, string>() {
        {
            "1",
            EMPRESAS},
        {
            "2",
            SOCIOS},
        {
            "6",
            CNAES_SECUNDARIOS}};

        public static Dictionary<string, ValueTuple<int, int>> GERAL_COLUNAS = new Dictionary<string, ValueTuple<int, int>>()
        {
            {"REGISTROS_TIPOS", (0, 1) },
        };
        

        public static Dictionary<string, ValueTuple<int, int>> EMPRESAS_COLUNAS = new Dictionary<string, ValueTuple<int, int>>() {
        {EMP_CNPJ, (3, 17)},
        {EMP_MATRIZ_FILIAL, (17, 18)},
        {EMP_RAZAO_SOCIAL, (18, 168)},
        {EMP_NOME_FANTASIA, (168, 223)},
        {EMP_SITUACAO, (223, 225)},
        {EMP_DATA_SITUACAO, (225, 233)},
        {EMP_MOTIVO_SITUACAO, (233, 235)},
        {EMP_NM_CIDADE_EXTERIOR, (235, 290)},
        {EMP_COD_PAIS, (290, 293)},
        {EMP_NOME_PAIS, (293, 363)},
        {EMP_COD_NAT_JURIDICA, (363, 367)},
        {EMP_DATA_INICIO_ATIV, (367, 375)},
        {EMP_CNAE_FISCAL, (375, 382)},
        {EMP_TIPO_LOGRADOURO, (382, 402)},
        {EMP_LOGRADOURO, (402, 462)},
        {EMP_NUMERO, (462, 468)},
        {EMP_COMPLEMENTO, (468, 624)},
        {EMP_BAIRRO, (624, 674)},
        {EMP_CEP, (674, 682)},
        {EMP_UF, (682, 684)},
        {EMP_COD_MUNICIPIO, (684, 688)},
        {EMP_MUNICIPIO, (688, 738)},
        {EMP_DDD_1, (738, 742)},
        {EMP_TELEFONE_1, (742, 750)},
        {EMP_DDD_2, (750, 754)},
        {EMP_TELEFONE_2, (754, 762)},
        {EMP_DDD_FAX, (762, 766)},
        {EMP_NUM_FAX, (766, 774)},
        {EMP_EMAIL, (774, 889)},
        {EMP_QUALIF_RESP, (889, 891)},
        {EMP_CAPITAL_SOCIAL, (891, 905)},
        {EMP_PORTE, (905, 907)},
        {EMP_OPC_SIMPLES, (907, 908)},
        {EMP_DATA_OPC_SIMPLES, (908, 916)},
        {EMP_DATA_EXC_SIMPLES, (916, 924)},
        {EMP_OPC_MEI, (924, 925)},
        {EMP_SIT_ESPECIAL, (925, 948)},
        {EMP_DATA_SIT_ESPECIAL, (948, 956)}
    };


        public static Dictionary<string, object> SOCIOS_COLUNAS = new Dictionary<string, object>() {
        {SOC_CNPJ, (3, 17)},
        {SOC_TIPO_SOCIO, (17, 18)},
        {SOC_NOME_SOCIO, (18, 168)},
        {SOC_CNPJ_CPF_SOCIO, (168, 182)},
        {SOC_COD_QUALIFICACAO, (182, 184)},
        {SOC_PERC_CAPITAL, (184, 189)},
        {SOC_DATA_ENTRADA, (189, 197)},
        {SOC_COD_PAIS_EXT, (197, 200)},
        {SOC_NOME_PAIS_EXT, (200, 270)},
        {SOC_CPF_REPRES, (270, 281)},
        {SOC_NOME_REPRES, (281, 341)},
        {SOC_COD_QUALIF_REPRES, (341, 343)}
    };



        public static object CNAES_COLNOMES = new List<string> (){
        CNA_CNPJ,
        "CNAE0",
        "CNAE1",
        "CNAE2",
        "CNAE3",
        "CNAE4",
        "CNAE5",
        "CNAE6",
        "CNAE7",
        "CNAE8",
        "CNAE9",
        "CNAE10",
        "CNAE11",
        "CNAE12",
        "CNAE13",
        "CNAE14",
        "CNAE15",
        "CNAE16",
        "CNAE17",
        "CNAE18",
        "CNAE19",
        "CNAE20",
        "CNAE21",
        "CNAE22",
        "CNAE23",
        "CNAE24",
        "CNAE25",
        "CNAE26",
        "CNAE27",
        "CNAE28",
        "CNAE29",
        "CNAE30",
        "CNAE31",
        "CNAE32",
        "CNAE33",
        "CNAE34",
        "CNAE35",
        "CNAE36",
        "CNAE37",
        "CNAE38",
        "CNAE39",
        "CNAE40",
        "CNAE41",
        "CNAE42",
        "CNAE43",
        "CNAE44",
        "CNAE45",
        "CNAE46",
        "CNAE47",
        "CNAE48",
        "CNAE49",
        "CNAE50",
        "CNAE51",
        "CNAE52",
        "CNAE53",
        "CNAE54",
        "CNAE55",
        "CNAE56",
        "CNAE57",
        "CNAE58",
        "CNAE59",
        "CNAE60",
        "CNAE61",
        "CNAE62",
        "CNAE63",
        "CNAE64",
        "CNAE65",
        "CNAE66",
        "CNAE67",
        "CNAE68",
        "CNAE69",
        "CNAE70",
        "CNAE71",
        "CNAE72",
        "CNAE73",
        "CNAE74",
        "CNAE75",
        "CNAE76",
        "CNAE77",
        "CNAE78",
        "CNAE79",
        "CNAE80",
        "CNAE81",
        "CNAE82",
        "CNAE83",
        "CNAE84",
        "CNAE85",
        "CNAE86",
        "CNAE87",
        "CNAE88",
        "CNAE89",
        "CNAE90",
        "CNAE91",
        "CNAE92",
        "CNAE93",
        "CNAE94",
        "CNAE95",
        "CNAE96",
        "CNAE97",
        "CNAE98",
        "CNAE99",
        };


        public static List<(int, int)> CNAES_COLSPECS = new List<(int, int)>() {
        (3, 17),
        (   17  ,   24  ),
        (   24  ,   31  ),
        (   31  ,   38  ),
        (   38  ,   45  ),
        (   45  ,   52  ),
        (   52  ,   59  ),
        (   59  ,   66  ),
        (   66  ,   73  ),
        (   73  ,   80  ),
        (   80  ,   87  ),
        (   87  ,   94  ),
        (   94  ,   101 ),
        (   101 ,   108 ),
        (   108 ,   115 ),
        (   115 ,   122 ),
        (   122 ,   129 ),
        (   129 ,   136 ),
        (   136 ,   143 ),
        (   143 ,   150 ),
        (   150 ,   157 ),
        (   157 ,   164 ),
        (   164 ,   171 ),
        (   171 ,   178 ),
        (   178 ,   185 ),
        (   185 ,   192 ),
        (   192 ,   199 ),
        (   199 ,   206 ),
        (   206 ,   213 ),
        (   213 ,   220 ),
        (   220 ,   227 ),
        (   227 ,   234 ),
        (   234 ,   241 ),
        (   241 ,   248 ),
        (   248 ,   255 ),
        (   255 ,   262 ),
        (   262 ,   269 ),
        (   269 ,   276 ),
        (   276 ,   283 ),
        (   283 ,   290 ),
        (   290 ,   297 ),
        (   297 ,   304 ),
        (   304 ,   311 ),
        (   311 ,   318 ),
        (   318 ,   325 ),
        (   325 ,   332 ),
        (   332 ,   339 ),
        (   339 ,   346 ),
        (   346 ,   353 ),
        (   353 ,   360 ),
        (   360 ,   367 ),
        (   367 ,   374 ),
        (   374 ,   381 ),
        (   381 ,   388 ),
        (   388 ,   395 ),
        (   395 ,   402 ),
        (   402 ,   409 ),
        (   409 ,   416 ),
        (   416 ,   423 ),
        (   423 ,   430 ),
        (   430 ,   437 ),
        (   437 ,   444 ),
        (   444 ,   451 ),
        (   451 ,   458 ),
        (   458 ,   465 ),
        (   465 ,   472 ),
        (   472 ,   479 ),
        (   479 ,   486 ),
        (   486 ,   493 ),
        (   493 ,   500 ),
        (   500 ,   507 ),
        (   507 ,   514 ),
        (   514 ,   521 ),
        (   521 ,   528 ),
        (   528 ,   535 ),
        (   535 ,   542 ),
        (   542 ,   549 ),
        (   549 ,   556 ),
        (   556 ,   563 ),
        (   563 ,   570 ),
        (   570 ,   577 ),
        (   577 ,   584 ),
        (   584 ,   591 ),
        (   591 ,   598 ),
        (   598 ,   605 ),
        (   605 ,   612 ),
        (   612 ,   619 ),
        (   619 ,   626 ),
        (   626 ,   633 ),
        (   633 ,   640 ),
        (   640 ,   647 ),
        (   647 ,   654 ),
        (   654 ,   661 ),
        (   661 ,   668 ),
        (   668 ,   675 ),
        (   675 ,   682 ),
        (   682 ,   689 ),
        (   689 ,   696 ),
        (   696 ,   703 ),
        (   703 ,   710 ),
        (   710 ,   717 )
        };

        public static Dictionary<string, Tuple<int, int>> HEADER_COLUNAS = new Dictionary<string, Tuple<int, int>> (){
        {"NomeDoArquivo", Tuple.Create(17, 28)},
        {"DataDaGravacao", Tuple.Create(28, 36)},
        {"NumeroDaRemessa", Tuple.Create(36, 44) }
        };

        public static Dictionary<string, object> TRAILLER_COLUNAS = new Dictionary<string, object> (){
        {"Total de registros de empresas", (17, 26)},
        {"Total de registros de socios", (26, 35)},
        {"Total de registros de CNAEs secundarios", (35, 44)},
        {"Total de registros incluindo header e trailler", (44, 55)}
        };

        //public static List<object> INDICES = new List<object>() {
        //("empresas_cnpj", EMPRESAS, EMP_CNPJ),
        //("empresas_raiz", EMPRESAS, EMP_CNPJ.Substring(0,9)),
        //("socios_cnpj", SOCIOS, SOC_CNPJ),
        //("socios_cpf_cnpj", SOCIOS, SOC_CNPJ_CPF_SOCIO),
        //("socios_nome", SOCIOS, SOC_NOME_SOCIO),
        //("cnaes_cnpj", CNAES_SECUNDARIOS, CNA_CNPJ)
        //};

        public static int CHUNKSIZE = 100000;
    }
}
