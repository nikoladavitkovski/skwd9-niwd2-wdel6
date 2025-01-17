﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc_server_Server
{
    public record Status
    {
        public int Code { get; private set; }
        public string Message { get; private set; }

        private Status(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public static string GenericErrorMessage = "Error occurred, please try again later!";

        public static Status OK = new(200, "OK");
        public static Status BadRequest = new(400, "Bad Request");
        public static Status NotFound = new(404, "Not Found");
        public static Status ServerError = new(500, "Internal Server Error");
    }
}
