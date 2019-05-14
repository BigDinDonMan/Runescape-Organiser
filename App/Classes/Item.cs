﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunescapeOrganiser {
    public class Item {

        public ulong Amount {
            get;set;
        }
        public string ItemName {
            get;set;
        }
        public decimal Price {
            get;set;
        }

        private DailyEarnings owner;

        public Item(string name, ulong amount, decimal Price) {
            this.ItemName = name;
            this.Amount = amount;
            this.Price = Price;
        }

        public void Add(Item si) {
            if (si == null || si.ItemName != this.ItemName) return;
            this.Price += si.Price;
            this.Amount += si.Amount;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Item sold: ");
            sb.Append(this.ItemName);
            sb.Append("\n");
            sb.Append("Quantity: ");
            sb.Append(this.Amount.ToString());
            sb.Append("\n");
            sb.Append("Total price: ");
            sb.Append(this.Price.ToString("0.##"));
            sb.Append("gp");
            return sb.ToString();
        }

        public string ToInfoString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("- ");
            sb.Append(this.Amount.ToString());
            sb.Append("x ");
            sb.Append(this.ItemName);
            sb.Append(" -> ");
            sb.Append(this.Price.ToString("0.##"));
            sb.Append("gp\n");
            return sb.ToString();
        }

        public void SetOwner(DailyEarnings newOwner) => this.owner = newOwner;
        public DailyEarnings GetOwner() => this.owner;
        public override bool Equals(object obj) {
            if (obj is Item item) {
                return this.ItemName.Equals(item.ItemName);
            }
            return false;
        }
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator==(Item si1, Item si2) => si1?.Equals(si2) ?? false;
        public static bool operator !=(Item si1, Item si2) => !si1?.Equals(si2) ?? false;
    }
}