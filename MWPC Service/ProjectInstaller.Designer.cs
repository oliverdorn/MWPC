namespace MWPC_Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.MWPCServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MWPCServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MWPCServiceProcessInstaller
            // 
            this.MWPCServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MWPCServiceProcessInstaller.Password = null;
            this.MWPCServiceProcessInstaller.Username = null;
            // 
            // MWPCServiceInstaller
            // 
            this.MWPCServiceInstaller.DisplayName = "MWPC Service";
            this.MWPCServiceInstaller.ServiceName = "MWPC Service";
            this.MWPCServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MWPCServiceProcessInstaller,
            this.MWPCServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MWPCServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller MWPCServiceInstaller;
    }
}