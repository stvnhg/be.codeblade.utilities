using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace be.codeblade.extensions
{
    public static class CBListExtensions
    {
        /// <summary>Sets the selected item of the dropdownlist</summary>
        /// <param name="ddl"></param>
        /// <param name="value">The value you want to select</param>
        public static void setSelectedItem(this DropDownList ddl, string value)
        {
            //Make sure no listitem is selected
            ddl.SelectedItem.Selected = false;

            //Loop over the items
            foreach (ListItem li in ddl.Items)
            {
                //If the values match
                if (li.Value.Equals(value))
                {
                    //Set the selected item to true and break the loop
                    li.Selected = true;
                    break;
                }
            }
        }
        /// <summary>Sets the selected item of the RadioButtonList</summary>
        /// <param name="rbtl"></param>
        /// <param name="value">The value you want to select</param>
        public static void setSelectedItem(this RadioButtonList rbtl, string value)
        {
            //Make sure no listitem is selected
            rbtl.SelectedItem.Selected = false;

            //Loop over the items
            foreach (ListItem li in rbtl.Items)
            {
                //If the values match
                if (li.Value.Equals(value))
                {
                    //Set the selected item to true and break the loop
                    li.Selected = true;
                    break;
                }
            }
        }

        /// <summary>Shuffles the list</summary>
        /// <typeparam name="T">Object type of the list</typeparam>
        /// <param name="source">The list of objects you need shuffled</param>
        /// <returns></returns>
        public static List<T> shuffle<T>(this List<T> source)
        {
            return source.shuffle(source.Count);
        }

        /// <summary>Shuffles the list</summary>
        /// <typeparam name="T">Object type of the list</typeparam>
        /// <param name="source">The list of objects you need shuffled</param>
        /// <param name="amount">The amount of items you need returned after the shuffling</param>
        /// <returns></returns>
        public static List<T> shuffle<T>(this List<T> source, int amount)
        {
            List<T> shuffledList = new List<T>();
            Random generator = new Random();

            while (source.Count > 0)
            {
                int position = generator.Next(source.Count);
                shuffledList.Add(source[position]);
                source.RemoveAt(position);

                if (shuffledList.Count >= amount)
                {
                    break;
                }
            }

            return shuffledList;
        }
    }
}
