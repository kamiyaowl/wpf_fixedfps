using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_fixedfps {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		/// <summary>
		/// 固定フレームレート
		/// </summary>
		public double FPS = 60;
		/// <summary>
		/// FPS固定で必ず呼ばれる
		/// </summary>
		public void OnUpdate() {
			//FPS固定で行いたい処理を記述
		}
		public MainWindow() {
			InitializeComponent();
		}
	}
}
