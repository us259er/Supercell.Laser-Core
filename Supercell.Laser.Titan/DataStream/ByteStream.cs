namespace Supercell.Laser.Titan.DataStream
{
    public class ByteStream
    {
        private int _bitOffset;

        private int _offset;
        private int _length;
        private byte[] _buffer;

        public ByteStream(int capacity)
        {
            _bitOffset = 0;
            _buffer = new byte[capacity];
        }

        public ByteStream(byte[] buffer)
        {
            _buffer = buffer;
            _length = buffer.Length;
        }

        /// <summary>
        /// Writes an Integer (4 bytes) to the stream.
        /// </summary>
        /// <param name="value">Value to write</param>
        public void WriteIntNoChecksum(int value)
        {
            EnsureCapacity(4);

            _bitOffset = 0;

            _buffer[_offset++] = (byte)(value >> 24);
            _buffer[_offset++] = (byte)(value >> 16);
            _buffer[_offset++] = (byte)(value >> 8);
            _buffer[_offset++] = (byte)value;
        }

        /// <summary>
        /// Writes a Long (8 bytes) to the stream.
        /// </summary>
        /// <param name="value">Value to write</param>
        public void WriteLong(long value)
        {
            EnsureCapacity(8);

            _bitOffset = 0;

            WriteIntNoChecksum((int)value >> 32);
            WriteIntNoChecksum((int)value);
        }

        internal void EnsureCapacity(int capacity)
        {
            if (_offset + capacity > _length)
            {
                byte[] newBuffer = new byte[capacity];
                Buffer.BlockCopy(_buffer, 0, newBuffer, 0, _length);
                _buffer = newBuffer;
            }
        }
    }
}
