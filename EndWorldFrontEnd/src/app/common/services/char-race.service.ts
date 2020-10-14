import { Injectable } from "@angular/core";
import { of, Observable } from 'rxjs';
import { CharClass } from '../char-class';
import { CharClassList } from '../assets/char-class-list';
import { CharRaceList } from '../assets/char-race-list';
import { CharRace } from '../char-race';

@Injectable()
export class CharRaceService {
    charRaceList: CharRaceList = new CharRaceList();
    getCharRaces(): Observable<CharRace[]>{
        return of(this.charRaceList.list)
    }

    getCharRaceByName(name): Observable<CharRace>{
        return of(this.charRaceList.list.filter(charClass => charClass.name == name)[0])
    }
}