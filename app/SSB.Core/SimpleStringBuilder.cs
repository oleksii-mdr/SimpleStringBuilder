namespace SSB.Core
{
    public class SimpleStringBuilder : ISimpleStringBuilder
    {
        public const int DefaultCapacity = 32;
        
        private char[] _internalBuffer;
        
        public int Lenght { get; private set; }
        public int Capacity { get; private set; }

        public SimpleStringBuilder(int capacity)
        {
            Capacity = capacity;
            _internalBuffer = new char[capacity];
            Lenght = 0;
        }

        public SimpleStringBuilder() : this(DefaultCapacity) { }

        public ISimpleStringBuilder Append(string value)
        {
            char[] data = value.ToCharArray();

            //check if space is available for additional data
            InternalEnsureCapacity(data.Length);

            foreach (char t in data)
            {
                _internalBuffer[Lenght] = t;
                Lenght++;
            }

            return this;
        }

        public ISimpleStringBuilder Clear()
        {
            _internalBuffer = new char[Capacity];
            Lenght = 0;
            return this;
        }

        public override string ToString()
        {
            //use only non-null ('\0') characters
            var tmp = new char[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                tmp[i] = _internalBuffer[i];
            }
            return new string(tmp);
        }

        private void InternalExpandBuffer()
        {
            //double capacity by default
            Capacity *= 2;

            //copy to new array
            var tmpBuffer = new char[Capacity];
            for (int i = 0; i < _internalBuffer.Length; i++)
            {
                char c = _internalBuffer[i];
                tmpBuffer[i] = c;
            }
            _internalBuffer = tmpBuffer;
        }

        private void InternalEnsureCapacity(int additionalLenghtRequired)
        {
            while (Lenght + additionalLenghtRequired > Capacity)
            {
                //not enough space in the current buffer    
                //double capacity
                InternalExpandBuffer();
            }
        }
    }
}