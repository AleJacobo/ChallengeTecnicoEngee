namespace Domain.Exceptions
{
    #region About: CustomException
    /// <summary>
    /// CustomException a nivel de negocio. Regresa Exceptions de logica de negocio, dejando las de systema con Exception
    /// </summary> 
    #endregion
    public class APIException : Exception
    {
        public APIException(string message) : base(message) { }
    }
}
