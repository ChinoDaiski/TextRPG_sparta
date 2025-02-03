using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_sparta
{
    internal class Shop
    {
        public List<Item> ItemsForSale { get; set; }  // 상점에서 판매하는 아이템 목록

        public Shop()
        {
            ItemsForSale = new List<Item>();  // 상점의 아이템 목록 초기화
        }

        // 상점에 아이템 추가
        public void AddItem(Item item)
        {
            ItemsForSale.Add(item);
        }

        // 상점 아이템 목록 표시
        public void ShowItems()
        {
            foreach (var item in ItemsForSale)
            {
                Console.WriteLine(item.ShowInfo());
            }
        }
        public void ShowItemsBuying()
        {
            int index = 1;
            foreach (var item in ItemsForSale)
            {
                Console.WriteLine($"- {index++}. " + item.ShowInfo());
            }
        }

        // 아이템 구매
        public bool BuyItem(Player player, Item item)
        {
            if (ItemsForSale.Contains(item))
            {
                if (player.Gold >= item.Price)
                {
                    player.Gold -= item.Price;  // 플레이어의 골드 차감
                    player.inventory.AddItem(item);  // 인벤토리에 아이템 추가
                    Console.WriteLine($"{item.Name}을(를) 구입했습니다.");
                    return true;
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("상점에 해당 아이템이 없습니다.");
                return false;
            }
        }
    }
}