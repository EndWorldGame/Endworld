import { Injectable } from "@angular/core";
import { of, Observable } from 'rxjs';
import { CharClass } from '../char-class';
import { CharClassList } from '../assets/char-class-list';

@Injectable()
export class CharClassService {
    charClassList: CharClassList = new CharClassList();
    getCharClasses(): Observable<CharClass[]>{
        return of(this.charClassList.list)
    }

    getCharClassByName(name): Observable<CharClass>{
        return of(this.charClassList.list.filter(charClass => charClass.name == name)[0])
    }
}