using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;
using System.Numerics.Tensors;
using System.Runtime.InteropServices;

namespace ConsoleAppSK.Examples;

public static class E05_EmbeddingSimilarity
{
    // In a real-case scenario, you can generate embedding for a user's question and query the similarity with stored embedded vectors in Redis, PostgresDB, Qdrant
    public static async Task Run()
    {
        // Once the APIs for this feature are stable, the experimental attribute will be removed

#pragma warning disable SKEXP0010, SKEXP0001, SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        // List<string> chunks = TextChunker.SplitPlainTextLines(_dogDescription, 50); // You can create small chunks

        Kernel kernel = Kernel.CreateBuilder()
            .AddOpenAITextEmbeddingGeneration(Settings.OpenAI.Models.Embedding_3_Small, Settings.OpenAI.ApiKey)
            .Build();

        var textEmbeddingService = kernel.GetRequiredService<ITextEmbeddingGenerationService>();

        List<string> embeddingInputs = [_question, _hotelDescription, _dogDescription];

        IList<ReadOnlyMemory<float>> embeddings = await textEmbeddingService.GenerateEmbeddingsAsync(embeddingInputs);
#pragma warning restore SKEXP0010, SKEXP0001, SKEXP0050 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        ReadOnlyMemory<float> questionEmbedding         = embeddings[0];
        ReadOnlyMemory<float> hotelDescriptionEmbedding = embeddings[1];
        ReadOnlyMemory<float> dogDescriptionEmbedding   = embeddings[2];

        float similarityWithHotel = TensorPrimitives.CosineSimilarity(questionEmbedding.Span, hotelDescriptionEmbedding.Span);
        float similarityWithDog   = TensorPrimitives.CosineSimilarity(questionEmbedding.Span, dogDescriptionEmbedding.Span);

        Console.WriteLine("Similarity with Hotel: {0} Dog: {1}", similarityWithHotel, similarityWithDog);
        // Output: 'Similarity with Hotel: 0,5539474 Dog: 0,056440584'

        Console.WriteLine("--- End of EmbeddingSimilarity ---");
    }

    private const string _question         = "Looking for a hotel with a pool and good location. Around lots of tourist attractions";
    private const string _hotelDescription = "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, and a really helpful concierge. The location is perfect -- right downtown, close to all the tourist attractions. We highly recommend this hotel.";
    private const string _dogDescription   = "Dogs are loyal and loving companions, known for their playful nature and boundless energy. They come in various breeds, each with unique traits and characteristics. Dogs can be great friends, offering comfort and joy to their owners. Their keen senses make them excellent protectors and helpers in various tasks.";

    // These methods can be useful, if so...
    private static byte[] floatToBytes(ReadOnlySpan<float> input)
    {
        return MemoryMarshal.AsBytes(input).ToArray();
    }

    private static ReadOnlyMemory<float> bytesToFloat(byte[] bytes)
    {
        ReadOnlySpan<float> floats = MemoryMarshal.Cast<byte, float>(new ReadOnlySpan<byte>(bytes));

        return floats.ToArray();
    }
}
