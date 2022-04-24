using System;
using System.Linq;
using System.Windows.Markup;

namespace CommonClasses.BaseClasses
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtension(Type type)
        {
            if (type is null || !type.IsEnum)
                throw new Exception("type must be an Enum and not null!");
            else
                EnumType = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var values = Enum.GetValues(EnumType);
            var filteredValues = values.Cast<Enum>().Where(w => w.ToString() != "Selezionare").ToList();
            return filteredValues;
        }
    }
}
