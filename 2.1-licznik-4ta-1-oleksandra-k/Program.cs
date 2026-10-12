using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace LicznikAplikacja
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                Application app = new Application();
                MainWindow window = new MainWindow();
                app.Run(window);
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("crash.log", ex.ToString());
            }
        }
    }

    public class MainWindow : Window
    {
        private int count = 0;
        private TextBlock countDisplay;
        private TextBlock statusText;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Konfiguracja okna głównego
            Title = "Licznik Kliknięć";
            Width = 380;
            Height = 460;
            MinWidth = 360;
            MinHeight = 440;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F5F9"));
            FontFamily = new FontFamily("Segoe UI, Arial");

            // Główny kontener
            Grid rootGrid = new Grid();
            rootGrid.Margin = new Thickness(20);

            // Karta z cieniem
            Border card = new Border();
            card.Background = Brushes.White;
            card.CornerRadius = new CornerRadius(16);
            card.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2E8F0"));
            card.BorderThickness = new Thickness(1);
            card.Padding = new Thickness(24);

            DropShadowEffect shadow = new DropShadowEffect();
            shadow.Color = (Color)ColorConverter.ConvertFromString("#0F172A");
            shadow.Opacity = 0.08;
            shadow.BlurRadius = 24;
            shadow.ShadowDepth = 6;
            shadow.Direction = 270;
            card.Effect = shadow;

            StackPanel panel = new StackPanel();
            panel.VerticalAlignment = VerticalAlignment.Center;

            // Nagłówek
            TextBlock titleText = new TextBlock();
            titleText.Text = "Licznik Kliknięć";
            titleText.FontSize = 22;
            titleText.FontWeight = FontWeights.Bold;
            titleText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0F172A"));
            titleText.HorizontalAlignment = HorizontalAlignment.Center;
            panel.Children.Add(titleText);

            TextBlock descText = new TextBlock();
            descText.Text = "Aplikacja desktopowa";
            descText.FontSize = 13;
            descText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#64748B"));
            descText.HorizontalAlignment = HorizontalAlignment.Center;
            descText.Margin = new Thickness(0, 4, 0, 16);
            panel.Children.Add(descText);

            // Blok z liczbą kliknięć
            Border countBox = new Border();
            countBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F8FAFC"));
            countBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E2E8F0"));
            countBox.BorderThickness = new Thickness(1);
            countBox.CornerRadius = new CornerRadius(12);
            countBox.Padding = new Thickness(16, 16, 16, 16);
            countBox.Margin = new Thickness(0, 0, 0, 20);

            StackPanel countInnerPanel = new StackPanel();

            TextBlock countLabel = new TextBlock();
            countLabel.Text = "LICZBA KLIKNIĘĆ";
            countLabel.FontSize = 11;
            countLabel.FontWeight = FontWeights.SemiBold;
            countLabel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#94A3B8"));
            countLabel.HorizontalAlignment = HorizontalAlignment.Center;
            countInnerPanel.Children.Add(countLabel);

            countDisplay = new TextBlock();
            countDisplay.Text = "0";
            countDisplay.FontSize = 60;
            countDisplay.FontWeight = FontWeights.Bold;
            countDisplay.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB"));
            countDisplay.HorizontalAlignment = HorizontalAlignment.Center;
            countDisplay.Margin = new Thickness(0, 4, 0, 0);
            countInnerPanel.Children.Add(countDisplay);

            statusText = new TextBlock();
            statusText.Text = "Kliknięto 0 razy";
            statusText.FontSize = 12;
            statusText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#64748B"));
            statusText.HorizontalAlignment = HorizontalAlignment.Center;
            statusText.Margin = new Thickness(0, 6, 0, 0);
            countInnerPanel.Children.Add(statusText);

            countBox.Child = countInnerPanel;
            panel.Children.Add(countBox);

            // Przycisk "Kliknij"
            Button clickButton = new Button();
            clickButton.Content = "Kliknij";
            clickButton.Height = 48;
            clickButton.Margin = new Thickness(0, 0, 0, 10);
            clickButton.Style = CreatePrimaryButtonStyle(
                (Color)ColorConverter.ConvertFromString("#2563EB"),
                (Color)ColorConverter.ConvertFromString("#1D4ED8"),
                Colors.White,
                10,
                16
            );
            clickButton.Click += ClickButton_Click;
            panel.Children.Add(clickButton);

            // Przycisk "Zeruj"
            Button resetButton = new Button();
            resetButton.Content = "Zeruj";
            resetButton.Height = 42;
            resetButton.Margin = new Thickness(0, 0, 0, 14);
            resetButton.Style = CreateSecondaryButtonStyle(
                (Color)ColorConverter.ConvertFromString("#F1F5F9"),
                (Color)ColorConverter.ConvertFromString("#E2E8F0"),
                (Color)ColorConverter.ConvertFromString("#CBD5E1"),
                (Color)ColorConverter.ConvertFromString("#334155"),
                10,
                14
            );
            resetButton.Click += ResetButton_Click;
            panel.Children.Add(resetButton);

            // Podpowiedź dot. skrótów klawiszowych
            TextBlock shortcutHint = new TextBlock();
            shortcutHint.Text = "Skróty: Spacja = Kliknij  |  R = Zeruj";
            shortcutHint.FontSize = 11;
            shortcutHint.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#94A3B8"));
            shortcutHint.HorizontalAlignment = HorizontalAlignment.Center;
            panel.Children.Add(shortcutHint);

            card.Child = panel;
            rootGrid.Children.Add(card);
            Content = rootGrid;

            // Obsługa skrótów klawiszowych
            KeyDown += MainWindow_KeyDown;
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            count++;
            UpdateUI();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            UpdateUI();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                count++;
                UpdateUI();
                e.Handled = true;
            }
            else if (e.Key == Key.R || e.Key == Key.Escape)
            {
                count = 0;
                UpdateUI();
                e.Handled = true;
            }
        }

        private void UpdateUI()
        {
            countDisplay.Text = count.ToString();
            string word = "razy";
            if (count == 1)
            {
                word = "raz";
            }
            statusText.Text = string.Format("Kliknięto {0} {1}", count, word);
        }

        // Metody pomocnicze do testowania logiki
        public int GetCount()
        {
            return count;
        }

        public void SimulateClick()
        {
            count++;
            UpdateUI();
        }

        public void SimulateReset()
        {
            count = 0;
            UpdateUI();
        }

        // Styl dla przycisku głównego
        private static Style CreatePrimaryButtonStyle(Color bgColor, Color hoverColor, Color textColor, double cornerRadius, double fontSize)
        {
            Style style = new Style(typeof(Button));

            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border), "border");
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(cornerRadius));
            border.SetValue(Border.BackgroundProperty, new SolidColorBrush(bgColor));
            border.SetValue(Border.BorderThicknessProperty, new Thickness(0));

            FrameworkElementFactory content = new FrameworkElementFactory(typeof(ContentPresenter));
            content.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            content.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            border.AppendChild(content);

            ControlTemplate template = new ControlTemplate(typeof(Button));
            template.VisualTree = border;

            Trigger hoverTrigger = new Trigger();
            hoverTrigger.Property = Button.IsMouseOverProperty;
            hoverTrigger.Value = true;
            hoverTrigger.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(hoverColor), "border"));
            template.Triggers.Add(hoverTrigger);

            Trigger pressedTrigger = new Trigger();
            pressedTrigger.Property = Button.IsPressedProperty;
            pressedTrigger.Value = true;
            pressedTrigger.Setters.Add(new Setter(Border.OpacityProperty, 0.85, "border"));
            template.Triggers.Add(pressedTrigger);

            style.Setters.Add(new Setter(Button.TemplateProperty, template));
            style.Setters.Add(new Setter(Button.ForegroundProperty, new SolidColorBrush(textColor)));
            style.Setters.Add(new Setter(Button.FontSizeProperty, fontSize));
            style.Setters.Add(new Setter(Button.FontWeightProperty, FontWeights.SemiBold));
            style.Setters.Add(new Setter(Button.CursorProperty, Cursors.Hand));

            return style;
        }

        // Styl dla przycisku pomocniczego
        private static Style CreateSecondaryButtonStyle(Color bgColor, Color hoverColor, Color borderColor, Color textColor, double cornerRadius, double fontSize)
        {
            Style style = new Style(typeof(Button));

            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border), "border");
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(cornerRadius));
            border.SetValue(Border.BackgroundProperty, new SolidColorBrush(bgColor));
            border.SetValue(Border.BorderBrushProperty, new SolidColorBrush(borderColor));
            border.SetValue(Border.BorderThicknessProperty, new Thickness(1));

            FrameworkElementFactory content = new FrameworkElementFactory(typeof(ContentPresenter));
            content.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            content.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            border.AppendChild(content);

            ControlTemplate template = new ControlTemplate(typeof(Button));
            template.VisualTree = border;

            Trigger hoverTrigger = new Trigger();
            hoverTrigger.Property = Button.IsMouseOverProperty;
            hoverTrigger.Value = true;
            hoverTrigger.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(hoverColor), "border"));
            template.Triggers.Add(hoverTrigger);

            Trigger pressedTrigger = new Trigger();
            pressedTrigger.Property = Button.IsPressedProperty;
            pressedTrigger.Value = true;
            pressedTrigger.Setters.Add(new Setter(Border.OpacityProperty, 0.85, "border"));
            template.Triggers.Add(pressedTrigger);

            style.Setters.Add(new Setter(Button.TemplateProperty, template));
            style.Setters.Add(new Setter(Button.ForegroundProperty, new SolidColorBrush(textColor)));
            style.Setters.Add(new Setter(Button.FontSizeProperty, fontSize));
            style.Setters.Add(new Setter(Button.FontWeightProperty, FontWeights.SemiBold));
            style.Setters.Add(new Setter(Button.CursorProperty, Cursors.Hand));

            return style;
        }
    }
}
