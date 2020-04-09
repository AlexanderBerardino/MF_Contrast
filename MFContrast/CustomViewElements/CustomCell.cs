using System;
using Xamarin.Forms;

namespace MFContrast.CustomViewElements
{
    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();

            Label left = new Label();
            Label right = new Label();

            //set bindings
            left.SetBinding(Label.TextProperty, "title");
            right.SetBinding(Label.TextProperty, "data");

            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#FFFFFF");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#69695D");
            right.TextColor = Color.FromHex("69695D");

            //add views to the view hierarchy
            horizontalLayout.Children.Add(left);
            horizontalLayout.Children.Add(right);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
}
