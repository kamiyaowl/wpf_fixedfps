using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace wpf_fixedfps {
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application {
		private void Application_Startup(object sender, StartupEventArgs e) {
			var mainWindow = new MainWindow();
			var isClosedMainWindow = false;
			mainWindow.Closed += (s, ex) => isClosedMainWindow = true;
			mainWindow.Show();

			long nextTick = 0;
			while (!isClosedMainWindow) {
				var currentTick = Environment.TickCount;
				/* 更新 */
				if (currentTick > nextTick) {
					mainWindow.OnUpdate();
					//次回実行時刻を指定
					var span = (long)Math.Floor(1000.0 / mainWindow.FPS);
					while (currentTick > nextTick) nextTick += span;
				}
				DoEvents();
			}
		}

		private void DoEvents() {
			var frame = new DispatcherFrame();
			DispatcherOperationCallback exitFrameCallback = f => {
				((DispatcherFrame)f).Continue = false;
				return null;
			};
			// 非同期で実行する
			var exitOperation = Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, exitFrameCallback, frame);

			// 実行ループを開始する
			Dispatcher.PushFrame(frame);

			// コールバックが終了していない場合は中断
			if (exitOperation.Status != DispatcherOperationStatus.Completed) {
				exitOperation.Abort();
			}
		}

		private void Application_Exit(object sender, ExitEventArgs e) {

		}
	}
}
