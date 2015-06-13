using NFluent;
using NUnit.Framework;

namespace DiamondKata.Test
{
    [TestFixture]
    public class DiamondTest
    {
        [Test]
        public void ShouldCreateASimpleDiamond()
        {
           var diamond = Diamond.Create('C');
            Check.That(diamond.Count).IsEqualTo(5);
            Check.That(diamond[0]).IsEqualTo("--A--");
            Check.That(diamond[1]).IsEqualTo("-B-B-");
            Check.That(diamond[2]).IsEqualTo("C---C");
            Check.That(diamond[3]).IsEqualTo("-B-B-");
            Check.That(diamond[4]).IsEqualTo("--A--");
        }
    }
}