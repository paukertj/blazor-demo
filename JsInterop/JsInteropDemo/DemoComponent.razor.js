export class DemoComponent {
    constructor(dotnetReference, videoElement, canvasElement, width, height) {
        this.dotnetReference = dotnetReference;

        this.videoElement = videoElement;
        this.canvasElement = canvasElement;
        this.canvasElement.width = width;
        this.canvasElement.height = height;

        this.constraints = {
            audio: false,
            video: true
        };
    }

    static factory(dotnetReference, videoElement, canvasElement, width, height) {
        return new DemoComponent(dotnetReference, videoElement, canvasElement, width, height);
    }

    handleSuccess(stream) {
        window.stream = stream; // make stream available to browser console
        this.videoElement.srcObject = stream;
    }

    handleError(error) {
        console.error('navigator.MediaDevices.getUserMedia error: ', error.message, error.name);
    }

    takeSnapshot() {
        this.canvasElement.width = this.videoElement.videoWidth;
        this.canvasElement.height = this.videoElement.videoHeight;

        this.canvasElement
            .getContext('2d')
            .drawImage(this.videoElement, 0, 0, this.canvasElement.width, this.canvasElement.height);

        if (this.dotnetReference != null) {
            this.dotnetReference.invokeMethodAsync('onSnapshotCallback', this.canvasElement.toDataURL());
        }
    }

    startRecording() {
        navigator.mediaDevices
            .getUserMedia(this.constraints)
            .then(this.handleSuccess
                .bind(this))
            .catch(this.handleError
                .bind(this));
    }
}