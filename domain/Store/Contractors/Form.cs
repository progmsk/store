using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Contractors
{
    public class Form
    {
        public string ServiceName { get; }

        public int Step { get; }

        public bool IsFinal { get; }

        private readonly Dictionary<string, string> parameters;
        public IReadOnlyDictionary<string, string> Parameters => parameters;

        private readonly List<Field> fields;
        public IReadOnlyList<Field> Fields => fields;

        public static Form CreateFirst(string serviceName)
        {
            return new Form(serviceName, 1, false, null);
        }

        public static Form CreateNext(string serviceName, int step, IReadOnlyDictionary<string, string> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            return new Form(serviceName, step, isFinal: false, parameters);
        }

        public static Form CreateLast(string serviceName, int step, IReadOnlyDictionary<string, string> parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            return new Form(serviceName, step, isFinal: true, parameters);
        }

        private Form(string serviceName,
                     int step,
                     bool isFinal,
                     IReadOnlyDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(serviceName))
                throw new ArgumentException(nameof(serviceName));

            if (step < 1)
                throw new ArgumentOutOfRangeException(nameof(step));

            ServiceName = serviceName;
            Step = step;
            IsFinal = isFinal;

            if (parameters == null)
                this.parameters = new Dictionary<string, string>();
            else
                this.parameters = parameters.ToDictionary(p => p.Key, p => p.Value);

            fields = new List<Field>();
        }

        public Form AddParameter(string name, string value)
        {
            parameters.Add(name, value);

            return this;
        }

        public Form AddField(Field field)
        {
            fields.Add(field);

            return this;
        }
    }
}
