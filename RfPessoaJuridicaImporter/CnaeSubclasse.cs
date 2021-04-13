

public class CnaeSubClasse
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public CnaeClasse Classe { get; set; }
    public string[] Atividades { get; set; }
    public string[] Observacoes { get; set; }
}

public class CnaeClasse
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public CnaeGrupo Grupo { get; set; }
    public string[] Observacoes { get; set; }
}

public class CnaeGrupo
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public CnaeDivisao Divisao { get; set; }
}

public class CnaeDivisao
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public CnaeSecao Secao { get; set; }
}

public class CnaeSecao
{
    public string Id { get; set; }
    public string Descricao { get; set; }
}




