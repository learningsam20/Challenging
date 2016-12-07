//http://stackoverflow.com/questions/15867478/build-tree-type-list-by-recursively-checking-parent-child-relationship-c-sharp

public class TreeList
        {
            public int ID { get; set; }

            public int? ParentID { get; set; }

            public List<TreeList> Children { get; set; }

        }
        static void Main(string[] args)
        {
            try
            {
                var t = new List<TreeList>(){
                        new TreeList() { ID = 1, ParentID = null },
                        new TreeList() { ID = 2, ParentID = 1 },
                        new TreeList() { ID = 3, ParentID = 1 },
                        new TreeList() { ID = 4, ParentID = 3 },
                        new TreeList() { ID = 5, ParentID = 4 },
                        new TreeList() { ID = 6, ParentID = 4 },
                        new TreeList() { ID = 7, ParentID = null },
                        new TreeList() { ID = 8, ParentID = 7 },
                        new TreeList() { ID = 9, ParentID = 8 }
                };
                var tree = BuildTree(t);
                Console.WriteLine("Recursion ended");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static List<TreeList> BuildTree(List<TreeList> items) {
            items.ForEach(i => i.Children = items.Where(ch => ch.ParentID == i.ID).ToList());
            return items.Where(i => i.ParentID == null).ToList();
        }
