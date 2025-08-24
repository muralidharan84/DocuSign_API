declare module '@pdftron/pdfjs-express' {
  export interface WebViewerConfig {
    path: string;
    initialDoc?: string;
    licenseKey?: string;
    [key: string]: any;
  }

  export interface WebViewerInstance {
    Core: {
      documentViewer: any;
      annotationManager: any;
    };
    Annotations: any;
    UI: any;
  }

  export default function WebViewer(
    config: WebViewerConfig,
    element: HTMLElement
  ): Promise<WebViewerInstance>;
}
