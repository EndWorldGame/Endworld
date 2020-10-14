import { Injectable } from "@angular/core";
import { of, Observable } from 'rxjs';
import { CharClass } from '../char-class';
import { CharClassList } from '../assets/char-class-list';
import { CharRaceList } from '../assets/char-race-list';
import { CharRace } from '../char-race';
import { Character } from '../character';

@Injectable()
export class PartyService {
    party: Character[] = [];

    addCharacter(character): void{
        this.party.push(character)
    }
    
    removeCharacter(name): void{
        this.party = this.party.filter(x => x.name != name)
    }

    getCharacterByName(name): Observable<Character> {
        return of(this.party.filter(x => x.name == name )[0])
    }

    getParty(): Observable<Character[]> {
        return of(this.party)
    }

    getPartySize(): number {
        return this.party.length;
    }
}