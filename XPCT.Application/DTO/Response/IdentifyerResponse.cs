namespace XPCT.Application.DTO.Response
{
    /// <summary>
    /// Resposta de Indentificação
    /// </summary>
    public class IdentifyerResponse
    {
        /// <summary>
        /// Id referente ao código do objeto manipulado
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Instancia um <see cref="IdentifyerResponse"/>
        /// </summary>
        /// <param name="id">código</param>
        public IdentifyerResponse(Guid id)
        {
            Id = id;
        }
    }
}
