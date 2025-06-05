namespace Global_Solution.Application.Dtos
{
    public class UsuarioDto
    {
        public int ID_USUARIO { get; set; }
        public string NOME_USUARIO { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public string TIPO_USUARIO { get; set; }
        public string SENHA_HASH { get; set; }
        public DateTime DATA_CADASTRO { get; set; }

    }
}
