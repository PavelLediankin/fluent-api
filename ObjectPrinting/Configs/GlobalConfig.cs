using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectPrinting.Configs
{
    internal class GlobalConfig
    {
        public Type[] FinalTypes =
        {
            typeof(int), typeof(double), typeof(float), typeof(string),
            typeof(DateTime), typeof(TimeSpan), typeof(Guid)
        };

        private readonly List<MemberInfo> excludedMembers = new List<MemberInfo>();
        public IReadOnlyList<MemberInfo> ExcludedMembers => excludedMembers;

        private readonly Dictionary<MemberInfo, Func<object, string>> alternativeMemberSerializations =
            new Dictionary<MemberInfo, Func<object, string>>();
        public IReadOnlyDictionary<MemberInfo, Func<object, string>> AlternativeMemberSerializations
            => alternativeMemberSerializations;

        public void AddExcludedMember(MemberInfo member)
            => excludedMembers.Add(member);

        public void AddAlternativeMemberSerialization
            (MemberInfo member, Func<object, string> serializationFunc)
            => alternativeMemberSerializations[member] = serializationFunc;
    }
}