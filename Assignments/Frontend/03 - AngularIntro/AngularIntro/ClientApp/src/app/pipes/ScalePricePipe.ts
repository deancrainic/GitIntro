import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'scalePrice'
})
export class ScalePricePipe implements PipeTransform {
    transform(price: number, percentage: number): number {
        return price + percentage / 100 * price;
    }
}