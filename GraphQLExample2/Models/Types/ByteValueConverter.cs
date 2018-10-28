using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLExample2
{
    public interface IAstFromValueConverter
    {
        bool Matches(object value);
        IValue Convert(object value);
    }

    public interface IValue : INode
    {
        object GetValue();
    }

    public sealed class ByteValue : IValue
    {
        public ByteValue(byte value)
        {
            Value = value;
        }

        public byte Value { get; }

        public IEnumerable<INode> Children => throw new NotImplementedException();

        public SourceLocation SourceLocation => throw new NotImplementedException();

        public object GetValue()
        {
            return Value;
        }

        public bool IsEqualTo(INode node)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class ByteValueConverter : IAstFromValueConverter
    {
        public bool Matches(object value)
        {
            return value is byte;
        }

        public IValue Convert(object value)
        {
            return new ByteValue((byte)value);
        }
    }

    public class ByteGraphType : ScalarGraphType
    {
        public ByteGraphType()
        {
            Name = "Byte";
        }

        public override object Serialize(object value)
        {
            return ParseValue(value);
        }

        public override object ParseValue(object value)
        {
            if (value == null)
                return null;

            try
            {
                var result = Convert.ToByte(value);
                return result;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public object ParseLiteral(IValue value)
        {
            var byteVal = value as ByteValue;
            return byteVal?.Value;
        }

        public override object ParseLiteral(GraphQL.Language.AST.IValue value)
        {
            throw new NotImplementedException();
        }
    }
}