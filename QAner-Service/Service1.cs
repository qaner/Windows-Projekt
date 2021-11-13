using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections;

namespace QAner_Service
{
    public partial class Service1 : ServiceBase
    {
        private string Debug { get; set; }
        private Hashtable config { get; set; }
        private string dir { get; set; }
        public Service1()
        {
            InitializeComponent();
        }

        public void Getmain()
        {
            this.OnStart(null);
        
        }

        private void save_log()
        {
            try
            {
                File.WriteAllText(dir + @"\debug.log", this.Debug);
            }
            catch (FileNotFoundException)
            {
                File.Create(dir + @"\debug.log");
            }
        }

        /* code-1        
        private void save_config(Hashtable config)
        {
            string str = "";
            str += config["name"] + "\n";
            str += config["version"] + "\n";
            str += config["last_run"] + "\n";
            str += config["date"] + "\n";
            str += config["dir"] + "\n";
            str += config["setup"] + "\n";
            str += config["debug_file"] + "\n";
            str += ";make for qaner#ntsys@servis:qaner";


            try
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"qaner.ini", str);
            }
            catch (FileNotFoundException)
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + @"qaner.ini");
            }
        }

        private void init_config()
        {
            config.Add("name", "qaner-serv");
            config.Add("version", "1.0.0.1:0");
            config.Add("last_run", "0:0:0:0:0");
            config.Add("date", DateTime.Now.ToString());
            config.Add("dir", AppDomain.CurrentDomain.BaseDirectory.ToString());
            config.Add("setup", "?null?");
            config.Add("debug_file", "debug.log");
        }*/

        private void printf(string str)
        {
            this.Debug += str;
        }

        protected override void OnStart(string[] args)
        {
            this.dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\qaner";

            printf("Hello by qaner!\n");

            if (Directory.Exists(dir))
            {
                printf("loading " + dir + "...\n");
            }
            else
            {
                printf("crateing " + dir + "...\n");
                Directory.CreateDirectory(dir);
            }
            
            
            printf("Hello by qaner!\n");
            printf("loading on " + dir + "...\n");

            this.save_log();
        }
        
        protected override void OnStop()
        {
        }
    }
}
