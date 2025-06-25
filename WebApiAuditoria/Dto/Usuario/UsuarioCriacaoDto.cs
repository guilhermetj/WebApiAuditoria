using System.ComponentModel.DataAnnotations;

namespace WebApiAuditoria.Dto.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        [Required(ErrorMessage = "Digite sua Senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite a Confirmação de Senha."), Compare("Senha", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmaSenha { get; set; }
    }
}
