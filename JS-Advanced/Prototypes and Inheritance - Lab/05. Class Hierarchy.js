function solve(){
    class Figure{
        constructor(units = `cm`){
            this.units = units;
        }

        get area(){

        }
        changeUnits(value){
            this.units = value;
        }
        toString(){
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure{
        constructor(radius, units){
            super(units);
            this._radius = radius;
        }
        
        get area(){
            return (this.radius ** 2) * Math.PI;
        }

        get radius(){
            let radius = this._radius;
            if (this.units == `m`){
                radius /= 10;
            }else if (this.units == `mm`){
                radius *= 10;
            }
            return radius;
        }
        
        toString(){
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure{
        constructor(width, height, units){
            super(units);
            this._width = width;
            this._height = height;
        }

        get width(){
            let width = this._width;
            if (this.units == `m`){
                width /= 10;
            }else if (this.units == `mm`){
                width *= 10;
            }
            return width;
        }
        get height(){
            let height = this._height;
            if (this.units == `m`){
                height /= 10;
            }else if (this.units == `mm`){
                height *= 10;
            }
            return height;
        }

        get area(){
            return this.width * this.height;
        }

        toString(){
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }
    return {Figure, Circle, Rectangle};
}