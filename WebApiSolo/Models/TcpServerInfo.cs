using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class TcpServerInfo
    {
        public int Id { get; set; }
        public int Port { get; set; }
        public string Ip { get; set; }
    }
}
