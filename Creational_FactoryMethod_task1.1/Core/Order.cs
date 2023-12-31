﻿namespace Creational_FactoryMethod_task1._1.Core;

public class Order: BaseData {
    public string? Department { get; set; }
    public DateTime DedLine { get; set; }
    public string? Executor { get; set; }

    public override string ToString() {
        return $"Department: {Department}, \n " +
               $"DedLine: {DedLine}, \n " +
               $"Executor: {Executor}\n";
    }
}