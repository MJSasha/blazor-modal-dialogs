# Blazor Modal Dialogs

The Blazor Modal Dialogs library provides developers with a convenient way to create and manage modal dialogs in Blazor applications. This README file serves as a guide to help you understand the key features and usage of the library.

## Features

- **Flexible Dialog Creation**: Easily create and customize modal dialogs by defining the dialog content, style, buttons, and other properties to suit your application's needs.

- **Modal Dialog Stack**: The library maintains a stack of modal dialogs, allowing you to show multiple dialogs sequentially. Each dialog can be independently managed, ensuring a smooth user experience.

## Installation

To install Blazor Modal Dialogs, follow these steps:

1. Open your Blazor application project.

2. Install the package from NuGet by running the following command in the Package Manager Console:

   ```
   Install-Package BlazorModalDialogs
   ```

   Alternatively, you can use the NuGet Package Manager in Visual Studio to search for and install the package.

3. Once the package is installed, you can start using the library in your Blazor components.

## Usage

To utilize Blazor Modal Dialogs in your application, follow these steps:

1. Add the necessary using statements to the `_Imports.razor` file:

   ```csharp
   @using BlazorModalDialogs
   @using BlazorModalDialogs.Components
   ```

2. Add styles to the `index.html` file:

   ```html
   <link href="_content/BlazorModalDialogs/css/styles.css" rel="stylesheet" />
   ```

3. Register the `DialogsService` in dependency injection (DI) in your application's `Startup.cs` or `Program.cs`:

   ```csharp
   builder.Services.AddSingleton<DialogsService>();
   ```

4. In your Blazor component, inject the `DialogsService`:

   ```csharp
   @inject DialogsService dialogsService
   ```

5. Use the `DialogsService` to show a modal dialog:

   ```csharp
   {ResultType} someResult = await dialogsService.Show<{DialogClass}, {DialogParamsClass}, {ResultType}>(new {DialogParamsClass} { ... });
   ```

## Dialog Example

Here's an example of an `InputDialog`:

Specify parameters for `InputDialog`:

```csharp
public class InputDialogParameters
{
    public string Title { get; set; }
}
```

Specify the `InputDialog` layout:

```csharp
@inherits Dialog<InputDialogParameters, string>

<DialogLayout IsDisplayed="IsDisplayed">
    <Modal Title="@Params.Title" OnClose="() => this.Cancel()" DisplayCenter="true" OnKeyEnterPressed="OnKeyEnterPressed">
        <Content>
            <input type="text" class="form-control mt-2" @bind-value="Value" @bind-value:event="oninput" />
        </Content>
        <Footer>
            <div class="mt-3">
                <ModalButton class="btn-outline-danger" OnClick="() => this.Cancel()">Cancel</ModalButton>
                <ModalButton class="btn-outline-success" OnClick="() => this.Close(Value)">Ok</ModalButton>
            </div>
        </Footer>
    </Modal>
</DialogLayout>

@code {
    protected string Value { get; set; }

    protected override void OnAfterShow()
    {
        Value = "";
        StateHasChanged();
    }

    protected void OnKeyEnterPressed()
    {
        this.Close(Value);
    }
}
```

Create `DialogsRegistrationForm`

```csharp
@using <...>.InputDialog;

<InputDialog/>
```

Put `DialogsRegistrationForm` to `MainLayout`

```csharp
@inherits LayoutComponentBase

<div class="page">
	<div class="sidebar">
		<NavMenu />
	</div>

	<main>
		<div class="top-row px-2">
			
		</div>

		<article>
			@Body
		</article>
	</main>
</div>
<DialogsRegistrationForm />
```

You can then:

- Show the dialog and get the input result:

  ```csharp
  var result = await dialogsService.Show<InputDialog, InputDialogParameters
  ```

- Close dialog

    ```csharp
    await dialogsService.Close<InputDialog, InputDialogParameters, string>();
    ```