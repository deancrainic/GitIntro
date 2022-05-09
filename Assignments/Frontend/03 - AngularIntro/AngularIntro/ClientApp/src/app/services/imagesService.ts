import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IImage } from "../image/image";
import { IProperty } from "../properties/models/property";

@Injectable()
export class ImageService {
    constructor(private http: HttpClient) {}

    postImage(image: IImage): Observable<IImage> {
        return this.http.post<IImage>("https://localhost:7154/api/Images", image);
    }

    addImageToProperty(propertyId: number, imageId: number) {
        return this.http.post<IImage>(`https://localhost:7154/api/Properties/${propertyId}/Images/${imageId}`, {propertyId, imageId});
    }
}