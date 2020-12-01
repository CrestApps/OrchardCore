using CrestApps.Pixulia.RealEstate.Shapes;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace CrestApps.Pixulia.RealEstate.Drivers
{
    public class CardShapeDriver : DisplayDriver<CardShape>
    {
        public override IDisplayResult Display(CardShape model)
        {
            ShapeResult header = View($"{nameof(CardShape)}_Display_Header", model)
                                    .Location("Header: 1");

            ShapeResult body = View($"{nameof(CardShape)}_Display_Body", model)
                                .Location("Body: 1");

            ShapeResult footer = View($"{nameof(CardShape)}_Display_Footer", model)
                                    .Location("Footer: 1");

            return Combine(header, body, footer);
        }
    }
}
