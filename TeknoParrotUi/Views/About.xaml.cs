using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using static TeknoParrotUi.MainWindow;

namespace TeknoParrotUi.Views
{
    public partial class About
    {
        public void UpdateVersions()
        {
            versionText.Text = GameVersion.CurrentVersion;
            components.Items.Clear();
            foreach (var component in MainWindow.components)
            {
                component._localVersion = null;
                components.Items.Add(new ListBoxItem
                {
                    Tag = component,
                    Content = $"{component.name} - {component.localVersion}"
                });
            }
        }

        public About()
        {
            InitializeComponent();
            UpdateVersions();
        }

        private void Components_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (components.SelectedItem != null)
            {
                var component = (UpdaterComponent)((ListBoxItem)components.SelectedItem).Tag;

                if (component != null)
                {
                    Process.Start(component.fullUrl);
                }
            }
        }
    }
}
