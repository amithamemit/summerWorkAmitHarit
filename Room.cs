using System;
using System.Collections.Generic;
using System.Text;

namespace summerWork2021
{
    class Room
    {
        private string _type;
        private float _length;
        private float _width;

        public Room(string type, float length, float width)
        {
            this._type = type;
            this._length = length;
            this._width = width;
        }

        public Room(Room room)
        {
            this._type = room.getType();
            this._length = room.getLength();
            this._width = room.getWidth();
        }

        public string getType()
        {
            return this._type;
        }

        public float getLength()
        {
            return this._length;
        }

        public float getWidth()
        {
            return this._width;
        }

        public void setType(string type)
        {
            this._type = type;
        }

        public void setLength(float length)
        {
            this._length = length;
        }

        public void setWidth(float width)
        {
            this._width = width;
        }

        public float getRoomArea()
        {
            return _length * _width;
        }

      
    }

    class Apartment
    {
        private string _owner;
        private Room[] _rooms;

        public Apartment(string owner)
        {
            this._owner = owner;
            this._rooms = new Room[10];
            for (int i = 0; i < 10; i++)
            {
                this._rooms[i] = null;
            }
        }

        public void SetOwner(string owner)
        {
            this._owner = owner;
        }
        public void setRooms(Room[] rooms)
        {
            this._rooms = rooms;
        }

        public string getOwner()
        {
            return this._owner;
        }

        public Room[] getRooms()
        {
            return this._rooms;
        }


        public float totalArea()
        {
            float totalArea = 0;
            for (int i = 0; i < 10 && this._rooms[i] != null; i++)
            {
                totalArea += this._rooms[i].getRoomArea();
            }
            return totalArea;
        }

        public string getCategory()
        {
            float size = this.totalArea();

            if (size < 70)
                return "small";

            else if (size <= 110)
                return "medium";

            else
                return "large";
        }
    }
}
