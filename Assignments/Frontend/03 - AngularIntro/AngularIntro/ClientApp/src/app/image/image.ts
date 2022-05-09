export class IImage {
    id: number;
    name: string;
    path: string;

    constructor(
        id: number = 1,
        name: string = '',
        path: string = ''
    ) {
        this.id = id;
        this.name = name;
        this.path = path;
    }
}