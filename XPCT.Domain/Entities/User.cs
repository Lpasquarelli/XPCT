namespace XPCT.Domain.Entities
{
    /// <summary>
    /// Entidade de Usuario
    /// </summary>
    public class User
    {
        /// <summary>
        /// Código de usuário
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// nome do usuário
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Flag de Operador/Cliente
        /// </summary>
        public bool Operator { get; private set; }

        /// <summary>
        /// <see cref="Entities.Wallet"/>
        /// </summary>
        public Wallet? Wallet { get; private set; }

        /// <summary>
        /// Instancia um <see cref="User"/>
        /// </summary>
        /// <param name="id">código do usuario</param>
        /// <param name="name">nome do usuario</param>
        /// <param name="email">email do usuario</param>
        /// <param name="Operator">flag de operador/cliente</param>
        /// <param name="wallet"><see cref="Entities.Wallet"/></param>
        public User(Guid id, string name, string email,bool Operator, Wallet wallet)
        {
            this.Id = id;
            this.Name = name;
            this.Operator = Operator;
            this.Email = email;
            this.Wallet = wallet;
        }

        /// <summary>
        /// Instancia um <see cref="User"/>
        /// </summary>
        /// <param name="id">código do usuario</param>
        /// <param name="name">nome do usuario</param>
        /// <param name="email">email do usuario</param>
        /// <param name="Operator">flag de operador/cliente</param>
        public User(Guid id, string name, string email, bool Operator)
        {
            this.Id = id;
            this.Name = name;
            this.Operator = Operator;
            this.Email = email;
        }

        /// <summary>
        /// Instancia um <see cref="User"/>
        /// </summary>
        /// <param name="name">nome do usuario</param>
        /// <param name="email">email do usuario</param>
        /// <param name="Operator">flag de operador/cliente</param>
        public User(string name, string email, bool Operator)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Operator = Operator;
            this.Email = email;
        }

        /// <summary>
        /// Carrega a carteira no usuário
        /// </summary>
        /// <param name="wallet"><see cref="Entities.Wallet"/></param>
        public void LoadWallet(Wallet wallet)
        {
            this.Wallet = wallet;
        }
    }
}
