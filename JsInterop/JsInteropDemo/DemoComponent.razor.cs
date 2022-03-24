using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace JsInteropDemo
{
    public partial class DemoComponent : IAsyncDisposable
    {
        [Parameter]
        public string? Base64Png { get; set; }

        [Parameter]
        public EventCallback<string?> Base64PngChanged { get; set; }

        private ElementReference _videoElementReference;
        private ElementReference _canvasElementReference;
        
        private IJSObjectReference? _jsInstance;

        private readonly DotNetObjectReference<DemoComponent>? _dotnetReference;
        private readonly Lazy<Task<IJSObjectReference>> _jsReference;

        public DemoComponent()
        {
            _dotnetReference = DotNetObjectReference.Create(this);
            _jsReference = new(async () => await _jsRuntime
                .InvokeAsync<IJSObjectReference>("import", "./_content/JsInteropDemo/DemoComponent.razor.js")
                .AsTask());
        }

        private async Task StartRecordingAsync()
        {
            var instance = await GetJsInstanceAsync();
            await instance.InvokeVoidAsync("startRecording");
        }

        private async Task TakeSnapshotAsync()
        {
            var instance = await GetJsInstanceAsync();
            await instance.InvokeVoidAsync("takeSnapshot");
        }

        [JSInvokable("onSnapshotCallback")]
        public async Task OnSnapshotAsync(string base64url)
        {
            Base64Png = base64url;

            if (Base64PngChanged.HasDelegate)
            {
                await Base64PngChanged.InvokeAsync(Base64Png);
            }
        }

        private async Task<IJSObjectReference> GetJsInstanceAsync()
        {
            if (_jsInstance != null)
            {
                return _jsInstance;
            }

            var reference = await _jsReference.Value;

            if (reference == null)
            {
                throw new NullReferenceException("Unable to get js reference!");
            }

            _jsInstance = await reference.InvokeAsync<IJSObjectReference>("DemoComponent.factory", _dotnetReference, _videoElementReference, _canvasElementReference, 480, 360);

            if (reference == null)
            {
                throw new NullReferenceException("Unable to get js instance!");
            }

            return _jsInstance;
        }

        public async ValueTask DisposeAsync()
        {
            if (_jsReference.IsValueCreated)
            {
                var module = await _jsReference.Value;
                await module.DisposeAsync();
            }

            if (_jsInstance != null)
            {
                await _jsInstance.DisposeAsync();
            }

            if (_dotnetReference != null)
            {
                _dotnetReference.Dispose();
            }
        }
    }
}
