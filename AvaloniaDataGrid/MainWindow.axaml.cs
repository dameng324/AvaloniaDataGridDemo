using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaDataGrid;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        for (int i = 0; i < 10; i++)
        {
            Persons.Add(new TestModel(i));
        }
        
        DataContext = this;

        this.Title += $" - DynamicCodeSupport:{RuntimeFeature.IsDynamicCodeSupported}";
    }

    public ObservableCollection<TestModel> Persons { get; } = new();
}

public class TestModel
{
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(Comparer<>))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(decimal))]
    public TestModel(decimal price)
    {
        Int32Field = price;
        DecimalField = price;
        DoubleField = (double)price;
        StringField = price.ToString();
        EnumField = Enum.GetValues<PlatformID>()[new Random().Next(0, Enum.GetValues<PlatformID>().Length)];
    }

    [Display(Name = "Decimal")] public decimal DecimalField { get; set; }
    [Display(Name = "Int32")] public decimal Int32Field { get; set; }
    [Display(Name = "Double")] public double DoubleField { get; set; }
    [Display(Name = "Enum")] public PlatformID EnumField { get; set; }
    [Display(Name = "String")] public string StringField { get; set; }
}