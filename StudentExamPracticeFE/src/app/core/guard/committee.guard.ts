import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AuthorizeService } from 'src/app/features/api-authorization/authorize.service';

@Injectable({
  providedIn: 'root'
})
export class CommitteeGuard {
  constructor(private authorizeService: AuthorizeService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.authorizeService.hasRole('Committee').pipe(
      map(hasCommitteeRole => {
        if (hasCommitteeRole) {
          return true;
        } else {
          return false;
        }
      })
    );
  }

}
