using System;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HypertableTimeColumnAttribute : Attribute { }
}