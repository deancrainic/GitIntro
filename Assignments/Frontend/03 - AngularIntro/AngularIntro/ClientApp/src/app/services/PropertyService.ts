import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IImage } from "../image/image";
import { IProperty } from "../properties/models/property";
import { ImageService } from "./imagesService";

@Injectable()
export class PropertyService {
    constructor(private http: HttpClient, private imageService: ImageService) {}

    getProperties(): Observable<IProperty[]> {
        return this.http.get<IProperty[]>("https://localhost:7154/api/Properties");
    }

    postProperty(property: any): Observable<IProperty> {
        return this.http.post<IProperty>("https://localhost:7154/api/Properties", property);
    }

    getProperty(id: number): Observable<IProperty> {
        return this.http.get<IProperty>(`https://localhost:7154/api/Properties/${id}`);
    }

    postImage(image: any): Observable<IImage> {
        return this.imageService.postImage(image);
    }

    addImageToProperty(propertyId: number, imageId: number): Observable<IImage> {
        return this.imageService.addImageToProperty(propertyId, imageId);
    }
}