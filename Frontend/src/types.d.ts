// https://emotion.sh/docs/typescript#define-a-theme
import "@emotion/react";

declare module "@emotion/react" {
  export interface Theme extends Record<string, any> {}
}
// import "@emotion/react";
// import { IPalette } from "../your-palette";

// declare module "@emotion/react" {
//   export interface Theme extends IPalette {}
// }
