using Microsoft.AspNetCore.Mvc.RazorPages;
using Szilveszter_Levente_Proiect.Data;

namespace Szilveszter_Levente_Proiect.Models
{
    public class ShipmentCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Szilveszter_Levente_ProiectContext context, Shipment shipment)
        {
            var allCategories = context.Category;
            var shipmentCategories = new HashSet<int>(
                shipment.ShipmentCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = shipmentCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateShipmentCategories(Szilveszter_Levente_ProiectContext context, string[] selectedCategories, Shipment shipmentToUpdate)
        {
            if (selectedCategories == null)
            {
                shipmentToUpdate.ShipmentCategories = new List<ShipmentCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var shipmentCategories = new HashSet<int>(shipmentToUpdate.ShipmentCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!shipmentCategories.Contains(cat.ID))
                    {
                        shipmentToUpdate.ShipmentCategories.Add(
                            new ShipmentCategory
                            {
                                ShipmentID = shipmentToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (shipmentCategories.Contains(cat.ID))
                    {
                        ShipmentCategory courseToRemove
                        = shipmentToUpdate
                            .ShipmentCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }                    
                }
            }
        }
    }
}
