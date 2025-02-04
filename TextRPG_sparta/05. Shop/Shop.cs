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
                Console.WriteLine(item.GetInfo());
            }
        }
        public void ShowItemsBuying()
        {
            int index = 1;
            foreach (var item in ItemsForSale)
            {
                Console.WriteLine($"- {index++}. " + item.GetInfo());
            }
        }

        // 아이템 구매
        public bool BuyItem(ref Player player, int index)
        {
            if (0 < index && index <= ItemsForSale.Count)
            {
                Item selectItem = ItemsForSale[index - 1];

                if (player.Gold >= selectItem.Price)
                {
                    player.Gold -= selectItem.Price;  // 플레이어의 골드 차감
                    player.inventory.AddItem(selectItem);  // 인벤토리에 아이템 추가
                    ItemsForSale.Remove(selectItem);    // 상점에서 아이템 제거
                    Console.WriteLine($"{selectItem.Name}을(를) 구입했습니다.");
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

        public bool SellItem(ref Player player, int index)
        {
            if (0 < index && index <= player.inventory.Items.Count)
            {
                // 판매할 아이템 선택
                Item selectItem = player.inventory.Items[index - 1];

                // 해당 아이템 정보를 장비하지 않은 상태로 변경
                selectItem.Equipment = false;

                // 아이템 정보를 플레이어에서 제거, 골드 추가
                player.inventory.RemoveItem(selectItem);
                player.Gold += (int)(selectItem.Price * 0.85f); // 85%만 돌려받음

                // 상점에 아이템 정보를 추가
                ItemsForSale.Add(selectItem);

                Console.WriteLine($"{selectItem.Name}을(를) 판매했습니다. + {selectItem.Price}G");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}