using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class AuthMessages
    {
        public static string USER_NOT_FOUND { get { return "User not found."; } }
        public static string PASSWORD_ERROR { get { return "Password has not been matched."; } }
        public static string SUCCESSFUL_LOGIN { get { return "Login has succeeded."; } }
        public static string USER_ALREADY_EXISTS { get { return "User already exists."; } }
        public static string USER_REGISTERED { get { return "User registered."; } }
        public static string CREATE_ACCESS_TOKEN_SUCCEED { get { return "Access token created."; } }
        

    }
}
