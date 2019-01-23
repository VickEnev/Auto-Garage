namespace AutoGarage.Controller
{
    /// <summary>
    /// Родителски клас за всички контролери
    /// </summary>
    public class Controller
    {
        protected Data.AutomobileDbContext context { get; set; }

        protected Controller(Data.AutomobileDbContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Edits the entity "model". Due to a bug in EF when you edit an entity it creates another entry of it in the DB.
        /// This method goes around that bug. 
        /// </summary>
        /// <typeparam name="T">The Type of the Entity</typeparam>
        /// <param name="model">The Entity you wish to edit</param>
        protected void EditEntity<T>(object model) where T : class
        {
                var entity = (T)model;

                context.Configuration.AutoDetectChangesEnabled = false;
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
                context.Configuration.AutoDetectChangesEnabled = true;
           
            
        }
    }
}
