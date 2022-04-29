namespace DucatiWebApi.DTO
{

    public class LoginResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string? Jwt { get; set; }
        public LoginResponseDTO()
        {

        }
        public LoginResponseDTO(bool isSuccess, string jwt)
        {
            IsSuccess = isSuccess;
            Jwt = jwt;
        }
        public static LoginResponseDTO Failed { get; internal set; }
    }
}
