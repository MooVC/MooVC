////namespace Mu.Modelling;

////using System.Linq;
////using MooVC.Syntax.CSharp.Elements;
////using MooVC.Syntax.CSharp.Generics;

////internal class Sample
////{
////    public Sample()
////    {
////        var model = new Model()
////            .For("Ers")
////            .Named("Registers")
////            .WithArea(area => area
////                .Named("Corporate")
////                .ResponsibleFor(unit => unit
////                    .Named("Company")
////                    .AttributedWith(directors => directors
////                        .Named("Directors")
////                        .OfType(typeof(string[])))
////                    .AttributedWith(name => name
////                        .Named("Name")
////                        .OfType(typeof(string)))
////                    .Featuring(feature => feature
////                        .Named("Register")
////                        .IsMutational(mutational => mutational
////                            .IsCreational()
////                            .Yields("Registered"))
////                        .Returning(result => result
////                            .Named("Id")
////                            .OfType(typeof(Guid))))));
////    }
////}