namespace DbLOL
{
    class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RegionId { get; set; }   // внешний ключ
        public Region Region { get; set; }  // навигационное свойство 

        public int RoleId { get; set; }     // внешний ключ
        public Role Role { get; set; }      // навигационное свойство
    }
}