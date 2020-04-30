
<div align=center><img src="icons/edrawingbar.png" width="200"/></div>

![lang](https://img.shields.io/badge/language-csharp-green.svg)
![Github](https://img.shields.io/badge/Github-build-blue.svg?style=flat-square)
![Github](https://img.shields.io/badge/Nuget-v1.0.1-yellowgreen.svg?style=flat-square)


# DuEDrawingControl

[English]((https://github.com/weianweigan/DuEDrawingControl/blob/master/README.md)) | 中文

在Winform和wpf中使用的edrawing 控件。使用了c# dynamic 类型封装，这样就不需要引用edrawing的dll，不需要额外配置，直接引用便可以使用。

**Winform:**

<div align=left><img src="icons/winform.png" width="400"/></div>

**WPF**

<div align=left><img src="icons/wpf.png" width="400"/></div>

## 安装

```
Install-Package DuEDrawingControl -Version 1.0.1
```

## 使用

### 1.Winform

```csharp

        private EDrawingView eDrawingView;

        private void Form1_Load(object sender, EventArgs e)
        {
            //add edrawing control when form loaded
            eDrawingView = new EDrawingView()
            {
                Dock = DockStyle.Fill
            };
            paneleDrawing.Controls.Add(eDrawingView);
        }

```

Clone this repository for more

### 2.WPF

```csharp
        private DuEDrawingControl.EDrawingWPFControl edrawing;

        public MainWindow()
        {
            InitializeComponent();

            //Add edrawing control
            edrawing = new DuEDrawingControl.EDrawingWPFControl() { 
                Margin = new Thickness(5)
            };
            edrawingPanel.Children.Add(edrawing);
        }
```

Clone this repository for more

## 示例

![](./icons/example.png)

## 实现的edrawing api

![api](./icons/api.png)

## Contact me

1831197727@qq.com