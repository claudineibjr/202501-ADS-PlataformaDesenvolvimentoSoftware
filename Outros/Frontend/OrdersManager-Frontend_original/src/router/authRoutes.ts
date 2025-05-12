import type { NavigationGuardNext, RouteLocationNormalized, RouteLocationNormalizedLoaded } from 'vue-router';
import { routes } from '.';

export default async function authRoutes(to: RouteLocationNormalized, from: RouteLocationNormalizedLoaded, next: NavigationGuardNext) {

  const authToken = window.localStorage.getItem("AUTH_TOKEN");

  const isAuthenticated = Boolean(authToken);
  const { requiresAuthentication } = to.meta;

  if (isAuthenticated) {
    if (requiresAuthentication) {
      next();
    } else {
      next(routes.orders);
    }
  } else {
    if (requiresAuthentication) {
      next(routes.login);
    } else {
      next();
    }
  }
}