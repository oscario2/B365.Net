using System.IO;
using B365.Public.Enums;
using B365.Public.Handlers;
using Xunit;

namespace B365.Public.Tests
{
    public class FrameUnitTests
    {
        [Fact]
        public void ParseFrame_Success()
        {
            var frame = File.ReadAllText("Resources/SportsBook.API.txt");
            FrameHandler.Parse(frame);
        }

        [Fact]
        public void ParseFrame_Empty()
        {
            Assert.Equal(EStatusCode.EmptyFrame, FrameHandler.Parse(null));
        }

        [Fact]
        public void ParseFrame_Invalid()
        {
            Assert.Equal(EStatusCode.InvalidFrame, FrameHandler.Parse("K"));
        }
    }
}